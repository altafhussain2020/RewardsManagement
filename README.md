# Rewards Management API
```
Author: Altaf Hussain Shaik
Designation: Full Stack Develper + Devops Engineer.
Created Date: 21-May-2022
```
**Introduction**

A retailer offers a rewards program to its customers awarding points based on each recorded 
purchase as follows:
```
For every dollar spent over $50 on the transaction, the customer receives one point.In addition, for every dollar spent over $100, the customer receives another point.
Ex: for a $120 purchase, the customer receives(120 - 50) x 1 + (120 - 100) x 1 = 90 pointsGiven a record of every transaction during a three-month period,
> Calculate the reward points earned for each customer per month and total.
> Make up a data set to best demonstrate your solution
> Check solution into GitHub
```
**Modules** 

This API Consists of the below Modules
- Create Transaction
- Update Transaction
- Delete Transaction
- List Transaction(s)
- List Customers
- Reward calculations engine 
- List Transaction(s) with Calculated Rewards
- List Customer Rewards Summary 
- Exception Handling & Logging
- Enabled Health Check for API
- Containerized the API with Docker File

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
> Docker Image : altafdocker2022/rewardsapi:v1.1
```
> Step1: Run the Docker Engine

> Step2 : docker run -it --rm -p 8080:80 --network=rmsapi altafdocker2022/rewardsapi:v1.1
```

**How to Test this API**

> Open Request through Postman

- GET Customer List : https://localhost:8080/customers

- GET Specific Customer : https://localhost:8080/customers/1001
```
 Pass Input as Customer Id. 
```

- GET Transactions List : https://localhost:8080/items

- GET Transaction Rewards list : https://localhost:8080/rewards

- GET Specific Transaction Rewards: https://localhost:8080/rewards/3fa85f64-5717-4562-b3fc-2c963f66afa6
```
 Pass Input as Transaction Id. 
```

- GET Rewards Summary :https://localhost:8080/summary/1
```
 Pass Input as No.Of Months.
      If you Pass 1 then API returns Current Month Data . 
      If you Pass 3 then API returns Last 3 Months Data . 
```
**API Health Check**
- Health Monitoring Link : http://localhost:8080/health
