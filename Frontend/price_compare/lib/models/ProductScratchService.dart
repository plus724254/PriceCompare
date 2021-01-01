import 'dart:convert';
import 'dart:io';

import 'ProductList.dart';

class ProductScratchService{
    final String _uri = "https://pricecompare.azurewebsites.net/api/Product?keyword=";

    Future<ProductList> getProductData (String keyword, String minPrice, String maxPrice) async {
      var httpClient = new HttpClient();
      var uri = Uri.parse(_uri+keyword+"&minPrice="+minPrice+"&maxPrice="+maxPrice);

      var request = await httpClient.getUrl(uri);
      var response = await request.close();

      var responseBody = await response.transform(utf8.decoder).join();
      httpClient.close();

      var data = json.decode(responseBody);

      if(data == null){
        return ProductList();
      }
      
      return ProductList.fromJson(data);
    }
}