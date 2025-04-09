
# Running the project locally
 
To run this project locally you'll only need [docker-compose](https://docs.docker.com/compose/).

You can find more information on how to install it [here](https://docs.docker.com/compose/install).

If you are currently using Windows, I would recommend using Ubuntu in WSL.
If you do not have WSL installed on your windows machine, take a look at [this guide](https://learn.microsoft.com/en-us/windows/wsl/install).

Make sure you have your terminal open on the root directory of the project folder and run the following command:

```
sudo docker-compose up 
```

After this command runs and all images and containers are created successfully, the API's SwaggerUI should be accessible by opening http://localhost:8080/swagger on your browser.


# Use cases

### List of devices in your system

* The endpoint `HTTP GET /devices` should return all devices in the database.
* New devices can be added using the `HTTP POST /devices`.


### List of measurements for a particular device
* The endpoint `HTTP GET /reports` should return all reports/measurements sent from all devices.
* A new report/measurement can be created using the `HTTP POST /reports` endpoint (be sure to create a device first and that the deviceId is valid).

_Since the reports/measurements have no use case in this exercise, I've opted to just have a simple message (string) in the Reports object_


### Retrieve information on how many messages each device generated
* This information can be quickly retrieved by calling the `HTTP GET /reports` endpoint with the respective `DeviceId` query parameter. The response body should include all reports with the same `DeviceId` and a `Count` property that displays how many reports that device has sent. 




