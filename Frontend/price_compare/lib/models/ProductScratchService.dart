import 'dart:convert';
import 'dart:io';

import 'ProductList.dart';

class ProductScratchService{
    final String _uri = "https://88668be36266.ngrok.io/api/Product?keyword=";

    Future<ProductList> getProductData (String keyword) async {
      var httpClient = new HttpClient();
      var uri = Uri.parse(_uri+keyword);

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