# kafka-netcore

### Run Kafka (Broker and Zookeeper on local machine)
- Navigate to kafka-netcore\kafka-broker\conduktor folder
- run `docker-compose up -d`

Kafka broker server and zookeeper should be running on a docker network called my_kafka_network (as configured inside the conduktor\docker-compose.yml file)

### Run .NET Core Solution
- Ensure docker-compose is set as startup project and hit F5

The docker-compose is configured to run the docker containers on the same my_kafka_network network so that it can communicate with the Kafka broker

### Test
- In postman, call POST `https://localhost:{PortNumber}/api/orders` with following:

```
{
    "Name": "My Order",
    "Quantity": 11
}
```
