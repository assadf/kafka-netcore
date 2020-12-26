# kafka-netcore

### Run Kafka (Broker and Zookeeper on local machine)
- Navigate to kafka-netcore/kafka-broker folder
- run `docker-compose up -d`

Kafka broker server and zookeeper should be running on a docker network called kafka-broker_default

### Run .NET Core Solution
- Ensure docker-compose is set as startup project and hit F5

The docker-compose is configured to run the docker containers on the kafka-broker_default network

### Test
- In postman, call POST `https://localhost:32876/api/orders` with following:

```
{
    "Name": "My Order",
    "Quantity": 11
}
```
