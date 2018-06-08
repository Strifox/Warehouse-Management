# Warehouse-Management
MVC Core project for Warehouse management with XUnitTesting.

Lab T2 - dependency injection
Du ska skapa en webapp och ett tillhörande testprojekt i Visual Studio. Laborationen ska utföras enskilt.
Det ska skrivas med TDD enligt red-green-refactor metodiken. Laborationen redovisas i skolan, senast 21/6.
Uppgiften
Du ska skapa ett ASP.NET MVC Core 2 projekt och ett tillhörande xUnit testprojekt. Skriv enhetstester för en controller.

En dependency är en klass som klassen vi ska testa är beroende av. Ett Entity Framework context är exempel på ett sådant. 
Testprojektet ska använda tekniken Dependency Injection med hjälp av interface och xUnit för att mocka dependencies. 
Det är tillåtet att använda testramverk som Moq i kombination med xUnit.

Du väljer själv innehåll och omfattning på MVC-projektet, men följande ska förekomma:
minst en dependency
controller med web API-metoder
affärslogik (uträkningar på datan)

Affärslogik (business logic) innebär i det här fallet att appen innehåller kod som
bestämmer hur datan får användas
kan göra något intressant eller intelligent med datan

Exempel på möjliga appar:
Lagerhantering - en användbar funktion är att räkna ut hur stort sammanlagt värde alla produkter som finns i lagret har. 
Alla produkter är inte lika. Sommardäck kanske bara lagras i sektion "A" men glofklubbor får vara var som helst.
Bilverkstad - hur lång tid det tar för en bil att bli reparerad i genomsnitt. Olika bilmodeller kan inte använda samma reservdelar.
Resebolag - vilka kunder som reser längst. Vissa turer kan vara begränsade, inga hundar på sträckan Göteborg - Oslo men ok på 
sträckan Göteborg - Stockholm.

Beroende
Du kan göra din egen dependency, eller utgå från följande. Interfacet beskriver en dependency för controllern, 
som är tänkt att användas på samma sätt som en databas.

interface IApiRequestSend<T> {
 	IEnumerable<T> GetAllData()
 	void AddEntity(T)
 	void ModifyEntity(id, T)
 	void DeleteEntity(T)
}

För att kunna köra appen (efter att du skrivit testen) så kan du göra en Fake av interfacet. 
Dvs en egen implementation av interfacet, där man kan anropa alla funktionerna och få testdata tillbaka.

Bedömningskriterier
För G
någon dependency mockas med dependency injection
minst tre testfall för web API-metoder
alla testfall är gröna

För VG
minst tre testfall för en klass med "business logic"
webappen ska gå att köra
web API-metoderna anropas med JavaScript/AJAX på någon sida
