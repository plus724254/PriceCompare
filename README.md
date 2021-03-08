# PriceCompare
即時電商比價APP
  

# 內容分類
* [項目簡介](#項目簡介)
* [項目背景](#項目背景)
* [安装](#安装)
* [項目負責人](#項目負責人)

# 項目簡介

為IOS、Android系統開發的比價APP，特性為即時爬蟲抓取當下最新之商品資訊，並進行排列與提供購買連結  
目前僅Android版本可用
  
<img src="https://i.imgur.com/1Q67IvF.png" width="227" height="492"/>

# 項目背景

現今的線上比價網站，往往因為龐大的使用者流量，不得不使用快取將過去的商品資料保留並快速回應給使用者，但往往因為這份資訊的延遲導致商品價格已與當下不符合。  
此比價系統會**即時**至電商網站爬取最新的商品資料，回傳最正確的即時資訊給予使用者，且此APP關注在我自己最常使用的大型電商，排除了較不可靠的私人賣場資訊，以符合個人使用習慣。

# 安装

開啟Flutter前端專案，輸入下方指令建置APK檔案
```console
flutter build apk
```
安裝後即可使用，預設使用此專案Azure App Service提供的爬蟲WEB API

# 項目負責人
[@plus724254](https://github.com/plus724254)
