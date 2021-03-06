# Timi sandbox project for back-end course

![Project Image](./Screenshot.png)

name     | value
----     | ----
language | C#
database | postgres
deployed | https://asp-net-sandbox-timi.herokuapp.com

## How to run in Docker from the commandline

Navigate to [AspNetSandbox](AspNetSandBox) directory

### Build in container
```
docker build -t web_timi .
```

to run

```
docker run -d -p 8081:80 --name web_container_timi web_timi
```

to stop container
```
docker stop web_container_timi
```

to remove container
```
docker rm web_container_timi
```

### Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a asp-net-sandbox-timi web
```

Release the container
```
heroku container:release -a asp-net-sandbox-timi web
```