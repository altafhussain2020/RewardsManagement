# Rewards Management API
```
Author: Altaf Hussain Shaik
Designation: Full Stack Develper + Devops Engineer.
Created Date: 21-May-2022
```
**Modules** 

This API Consists of the below Modules
- Create Transaction
- Update Transaction
- Delete Transaction
- List Transaction(s)
- List Customers
- Reward calculations module Completed
- List Transaction(s) with Calculated Rewards
- List Customer Rewards Summary 
- Exception Handling & Logging
- Enabled Health Check for API
- Containerize the API with Docker File

**Data Storage**
> InMemory Data Maintenance Mode

# Dataset Sample

![This is an image](https://github.com/altafhussain2020/RewardsManagement/blob/master/assets/Images/RM_Transactions.jpg)

![This is an image](https://github.com/altafhussain2020/RewardsManagement/blob/master/assets/Images/RM_Customer.jpg)

![This is an image](https://github.com/altafhussain2020/RewardsManagement/blob/master/assets/Images/RM_TransactionRewards.jpg)

![This is an image](https://github.com/altafhussain2020/RewardsManagement/blob/master/assets/Images/RM_Transactions.jpg)

**Technology Specifications**
- ASP.Net Web API .NET Core 5.0
- Docker Containerization

**How to Deploy Docker Container**
> Docker Image : altafdocker2022/rewardsapi:v1
```
> Step1: Run the Docker Engine

> Step2 : docker run -it --rm -p 8080:80 --network=rmsapi altafdocker2022/rewardsapi:v1.1
```

**How to Test this API**

- Get Customer List : https://localhost:8080/customers

- Get Specific Customer : https://localhost:8080/customers/1001
```
 Pass Input as Customer Id. 
```

- Get Transactions List : https://localhost:8080/items

- Get Transaction Rewards list : https://localhost:8080/rewards

- GetSpecific Transaction Rewards: https://localhost:8080/rewards/3fa85f64-5717-4562-b3fc-2c963f66afa6
```
 Pass Input as Transaction Id. 
```

- Get Rewards Summary :https://localhost:8080/summary/1
```
 Pass Input as No.Of Months. If you Pass 1 then API retruns Currenct Month Data
```
**API Health Check**
- Health Monitoring Link : http://localhost:8080/APIHealth
