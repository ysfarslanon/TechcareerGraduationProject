# Backend

## Kurulum
1. Proje klasörü içinde bulunan TechcareerShoppingTracking klasöründe ```TechcareerShoppingTracking.sln``` dosyasını [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) ile açın.
2. Solution Explorer > WebAPI katmanına sağ tıklayıp ***Set as Startup Project*** seçeneğini seçiniz. (**Projeyi IIS Express olarak çalıştırmayın!**)
3. *View > SQL Server Object Explorer* penceresinden bir adet veri tabanı oluşturunuz. 
    - Bu pencere çıkmıyorsa *Tools > Get Tools and Features.. > Other Toolsets > Data storage and processing* seçeneğini seçip Modify butonuna tıklayıp programı yeniden başlatınız.
4. Veri tabanınızın ***Connection string*** ini ***appsetting.json*** dosyasında bulunan ***DbString*** ile değiştiriniz.
5. *View > Other Windows > Package Manager Console* penceresini açınız ***Default project: DataAccess*** olarak ayarlayın ve alttaki komutu çalıştırınız.
```
update-database
```
6. Backend kurulumu bitmiştir [Frontend kurulumuna geçebilirsiniz.](https://github.com/ysfarslanon/TechcareerGraduationProject/tree/main/AngularShoppingList)

## Kullanılan teknolojiler/araçlar
- .Net 6
- Entity Framework 6
- Code First
- MSSQL
- Katmanlı mimari
- Generic repository pattern
- Jwt
- Fluent Validation
- Swagger

*Dto kullanarak entity nesneleri API tarafında kullanılmamıştır.*