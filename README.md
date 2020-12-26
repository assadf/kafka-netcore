# kafka-netcore

### Create docker network (called myshop)
- `docker network create myshop` - this will be the docker network that kafka broker, zookeeper and all producers/consumers which need to communicate with kafka will run on.

**Note:** to check what networks there are run `docker network ls`

### Run Kafka (Broker and Zookeeper on local machine)
- Navigate to kafka-netcore/kafka-broker folder
- run `docker-compose up -d`

Kafka broker server and zookeeper should be running on a docker network called myshop

### Run .NET Core Solution
- Ensure docker-compose is set as startup project and hit F5

### Test
- In postman, call POST `https://localhost:32876/api/orders` with following:

```
{
    "Name": "My Order",
    "Quantity": 11
}
```
