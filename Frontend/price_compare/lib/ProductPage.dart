import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'models/Product.dart';
import 'models/ProductList.dart';
import 'models/ProductScratchService.dart';
import 'package:url_launcher/url_launcher.dart';


class ProductPage extends StatefulWidget{
  @override
  _ProductPageState createState(){
    return _ProductPageState();
  }
}


class _ProductPageState extends State<ProductPage>{
  final TextEditingController _filter = TextEditingController();
  
  var _products = ProductList();

  var _searchIcon = Icon(Icons.search);


  _ProductPageState() {
    _products.products = List<Product>();
  }

  @override
  Widget build(BuildContext context){
    return Scaffold(
      appBar: _buildBar(context),
      body: _buildList(context),

    );
  }

  Widget _buildBar(BuildContext context){
    return AppBar(
      backgroundColor: Colors.blueGrey,
      title: _barTitle(context),
      leading: IconButton(
        icon: _searchIcon, 
        onPressed: () async {_searchPressed();},
      )
    );
  }

  Widget _barTitle(BuildContext context){
    return TextField(
      controller: _filter,
      onSubmitted: (str) {_searchPressed();},
      decoration: InputDecoration(
        hintText: '商品名稱',
      ),
    );
  }

  Widget _buildList(BuildContext context){
    return ListView.builder(
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
    var products = await ProductScratchService().getProductData(_filter.text);
    setState(() {
        this._products.products = products.products;
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
}