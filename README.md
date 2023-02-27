# Monolith & Microservices comparison
This project demonstrates API application  built in two different architectures.
## How to run
### MonolithApp
1. Create SQL database and change connection string in dbcontex instance
2. Run project CustomerStoreMonolitApi
3. Hit endpoint with following request 
```
curl --location --request GET 'https://localhost:44311/customers/1'
```

### Microservices app
1. Create SQL database and change connection string in dbcontex instance
2. Run projects: CustomerService, CommonService, CustomerStoreMicroservicesApi or use the docker file to deploy on cluster
3. Hit endpoint with following request 
```
curl --l
