import 'package:flutter/material.dart';
import 'ProductPage.dart';
import 'helpers/Constants.dart';

void main() {
  runApp(PriceCompareApp());
}

class PriceCompareApp extends StatelessWidget {
  final routes = <String, WidgetBuilder>{
    productPageTag: (context) => ProductPage(),
  };
  
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: "appTitle",
      theme: ThemeData(
        primaryColor: Colors.grey,
      ),
      home: ProductPage(),
      routes: routes,
    );
  }
}

