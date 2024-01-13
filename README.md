# Create web service server using WCF core

Use [CoreWCF](https://github.com/CoreWCF/CoreWCF)

- Install extension for WCF templates

```dotnet new --install CoreWCF.Templates```

- Create project

```dotnet new corewcf --name EccGw```

- run initial template

```dotner run```

- check web service metadata (wsdl) at [https://localhost:7220/Service.svc?singleWsdl](https://localhost:7220/Service.svc?singleWsdl) and familiar WCF page [Service.svc](
https://localhost:7220/Service.svc)


- open it in VS ```start EccGw.csproject``` or VS Code ```code .```