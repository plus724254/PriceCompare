import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'models/Product.dart';
import 'models/ProductList.dart';
import 'models/ProductScratchService.dart';
import 'package:url_launcher/url_launcher.dart';
import 'package:loading_animations/loading_animations.dart';


class ProductPage extends StatefulWidget{
  @override
  _ProductPageState createState(){
    return _ProductPageState();
  }
}


class _ProductPageState extends State<ProductPage>{
  final TextEditingController _filter = TextEditingController();
  final TextEditingController _minPricefilter = TextEditingController();
  final TextEditingController _maxPricefilter = TextEditingController();

  var _appBarBackgroundColor = Colors.teal[700];
  var _filterBackgroundColor = Colors.teal[400];
  var _products = ProductList();
  var _searchIcon = Icon(Icons.search);
  var _filterIcon = Icon(Icons.done_outline);

  var _isHardSearchCheck = false;
  var _isLoadingAnimationDisplay = false;

  _ProductPageState() {
    _products.products = List<Product>();
  }

  @override
  Widget build(BuildContext context){
    return Scaffold(
      appBar: _buildBar(context),
      body: Column(
        children:[
          _buildFilter(context),
          _buildLoadAnimation(context),
          Expanded(
            child: _buildList(context)
          ),
        ]
      ),

    );
  }

  Widget _buildBar(BuildContext context){
    return AppBar(
      backgroundColor: _appBarBackgroundColor,
      title: _barTitle(context),
      leading: IconButton(
        icon: _searchIcon, 
        splashColor: Colors.white,
        onPressed: () async {_searchPressed();},
      )
    );
  }

  Widget _barTitle(BuildContext context){
    return Row(
      children: [
        Expanded(
          flex: 50,
          child: TextField(
            controller: _filter,
            onSubmitted: (str) {_searchPressed();},
            decoration: InputDecoration(
              hintText: '商品名稱',
              //border: InputBorder.none,
            ),
          ),
        ),
        Expanded(
          flex: 5,
          child: Container(),
        ),
        Expanded(
          flex: 45,
          child: Row(
              children: [
                Text(
                  "精準搜尋",
                  style: TextStyle(fontSize: 14),
                ),
                Switch(
                  value: _isHardSearchCheck,
                  onChanged: _hardSearchChanged,
                  activeColor: Colors.yellowAccent,
                ),

              ]
          ),
        ),
      ],
    );
  }

  Widget _buildLoadAnimation(BuildContext context){
    var content;
    if(_isLoadingAnimationDisplay)
    {
        content = Container(
          padding: EdgeInsets.symmetric(vertical: 50 , horizontal: 0),
          child: LoadingRotating.square(
            borderColor: Colors.blueGrey,
            size: 50.0
          )
        );
    }
    else
    {
        content = Container(height: 0,width: 0);
    }

    return content;
  }

  Widget _buildFilter(BuildContext context){
    return Container(
      padding: EdgeInsets.symmetric(vertical: 0 , horizontal: 30.0),
      width: MediaQuery.of(context).size.width,
      height: 50,
      color: _filterBackgroundColor,
      child: Row(
        children: [
          Text('價格範圍'),
          _buildMinPriceFilter(context),
          Text('-'),
          _buildMaxPriceFilter(context),
          Material(
            color: _filterBackgroundColor,
            child: IconButton(
              icon: _filterIcon, 
              splashColor: Colors.white,
              onPressed: () async {_searchPressed();},
            ),
          ),
        ],
      )
    );
  }

  Widget _buildMinPriceFilter(BuildContext context){
    return Container(
      width: 105,
      height: 30,
      padding: EdgeInsets.symmetric(vertical: 0 , horizontal: 10.0),
      child: TextField(
        
        style: TextStyle(
          fontSize: 14.0,
        ),
        controller: _minPricefilter,
        decoration: InputDecoration(
          hintText: '最低價',
          border: InputBorder.none,
          fillColor: Colors.white, 
          filled: true,
          isDense: true,
        ),
      ),
      decoration: BoxDecoration(
        borderRadius: new BorderRadius.all(new Radius.circular(1000.0)),
      ),
    );
  }

  Widget _buildMaxPriceFilter(BuildContext context){
    return Container(
      width: 105,
      height: 30,
      padding: EdgeInsets.symmetric(vertical: 0 , horizontal: 10.0),
      child: TextField(
        
        style: TextStyle(
          fontSize: 14.0,
        ),
        controller: _maxPricefilter,
        decoration: InputDecoration(
          hintText: '最高價',
          border: InputBorder.none,
          fillColor: Colors.white, 
          filled: true,
          isDense: true,   
        ),
      )
    );
  }

  Widget _buildList(BuildContext context){
    return 
    ListView.builder(
      itemCount: _products.products.length,
      itemBuilder: (context, index){
        return Container(
          decoration: BoxDecoration(
            border: Border(bottom: BorderSide(width: 8, color: Colors.grey )),
          ),
          padding: const EdgeInsets.only(bottom: 10.0),
          height: 120,
          width: double.infinity,
          child: GestureDetector(
            onTap: (){_lunchUrl(_products.products[index].pageUrl);},
            child: Row(
              children: [
                Expanded(
                  flex: 4,
                  child: Image.network(_products.products[index].imageUrl)
                ),
                Expanded(
                  flex: 6,
                  child: Column(
                    children: [
                      Expanded(
                        flex: 65,
                        child: Text(_products.products[index].name, style: TextStyle(fontSize: 14, fontWeight: FontWeight.bold)),
                      ),
                      Expanded(
                        flex: 15,
                        child: Padding(
                          padding: const EdgeInsets.only(right: 20.0),
                          child: Align(
                            alignment: Alignment.centerRight,
                            child: Text(_products.products[index].webSiteName, style: TextStyle(fontSize: 12, color: Colors.grey)),
                          ),
                        ),
                      ),
                      Expanded(
                        flex: 20,
                        child: Padding(
                          padding: const EdgeInsets.only(right: 8.0),
                          child: Align(
                            alignment: Alignment.centerRight,
                            child: Text("\$"+_products.products[index].price.toString(), style: TextStyle(fontSize: 18, color: Colors.red))
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ) 
          ),
          
        );
      }
    );
  }


  _searchPressed() async {
      setState(() {
        this._products.products = new List<Product>();
        _isLoadingAnimationDisplay = true;
      }
    );

    var products = await ProductScratchService().getProductData(_filter.text, _minPricefilter.text, _maxPricefilter.text,_isHardSearchCheck);
    setState(() {
        this._products.products = products.products;
        _isLoadingAnimationDisplay = false;
      }
    );
  }

  _lunchUrl(String url) async{
     if (await canLaunch(url)) {
      await launch(url);
    } else {
      throw 'Could not launch $url';
    }
  }

  _hardSearchChanged(isHardSearchCheck) {
    setState((){
      _isHardSearchCheck = isHardSearchCheck;
    });
  }
}