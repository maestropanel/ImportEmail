#MaestroPanel Import Email
Virgül ile ayrılmış dosyada tutulan eposta adreslerini MaestroPanel'e aktarmanızı sağlar.

## Download
https://github.com/maestropanel/ImportEmail/releases

## Parametreler

**--host**	

MaestroPanel'in çalıştığı sunucu IP adresi veya host adı.

**--apikey** 

MaestroPanel'de oluşturduğunuz admin veya reseller haklarına sahip API anahtarı. (*MaestroPanel'de nasıl API key oluşturulacağına dair dokümanımızı inceleyiniz https://wiki.maestropanel.com/maestropanelde-api-anahtari-olusturma/*)

**--port**

MaestroPanel'in çalıştığı port numarası. Varsayılan olarak 9715 olarak kabul edilir.

# Kullanım

importemail.exe dosyasının bulunduğu dizinde Emails.txt dosyasını oluşturun. 
Emails.txt dosyasının içine MaestroPanel'e eklemek istediğiniz eposta adreslerini aşağıdaki formata göre ekleyin.

    [Eposta Sahibinin İsmi], [Eposta Adresinin Tamamı], [Eposta Parolası], [Eposta'nın Kotası]

*Not: Köşeki parantezler daha iyi okunabilsin diye eklenmiştir. Gerçek dosyada köşeli parantez eklemenize gerek yoktur.*

**Örnek Dosya İçeriği:**

    Sarı Çizmeli, saric@deneme.com, 12345Osman, 100
    Mehmet Ağa, maga@deneme.com, 12345Osman, 150
    Patron Super, psuper@deneme.com, 12345Osman, 200


**Örnek Kullanım:**

    importemail.exe --host=192.168.5.2 --apikey=1_edae6375c0af496691df31dbc036d615

**Özel bir porta kullanıyorsanız:**

    importemail.exe --host=192.168.5.2 --apikey=1_edae6375c0af496691df31dbc036d615 --port=443


## İletişim

ping@maestropanel.com
