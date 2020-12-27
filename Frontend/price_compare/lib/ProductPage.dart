import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'models/Product.dart';
import 'models/ProductList.dart';
import 'models/ProductScratchService.dart';


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
          decoration: BoxDecoration(           // 裝飾內裝元件
                                          // 綠色背景
            border: Border(bottom: BorderSide(width: 8, color: Colors.grey )), // 藍色邊框
          ),
          padding: const EdgeInsets.only(bottom: 10.0),
          height: 200,
          width: double.infinity,
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
                    Text(_products.products[index].name),
                    Text(_products.products[index].detail),
                    Text(_products.products[index].price),
                  ],
                ),
              ),

            ],
          ) 
            
            
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
}