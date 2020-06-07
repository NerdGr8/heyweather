# A Helm Story, Kubernetes for you and me.

So I'm having to dive into some helm config work. Helm is a Kubernetes dependency management tool. Its primary artifacts, "Charts". They define an application and its dependencies at best. Picture a chart as a bundled deployable resource in a K8s cluster. 

I find Helm provides a better scaffolding experience to creating and managing an application's configuration files, service.yml, deployment.yml, etc. It has a declarative approach to documenting your environment and provides versioning. It provides a CLI interface, similar to Docker.
Most config work is done through YAML files. As with Docker-compose files, environment values are stored in a values.yml.

### Lets get to making a chart.
I'll be using a Macbook for most of the work. Running a different OS, have a look over here:
- [Install Helm](https://helm.sh/docs/intro/install/). 
- [Visual Studio Code](https://code.visualstudio.com/).

1. Install helm through brew (Mac):
`sudo brew install helm`

2. Assuming you have an existing application that you would like to add helm. \
`cd directory-path/ && mkdir helm && cd helm` \
*This will create a directory helm, I prefer to separate my deployment config from my application source code.* \

3. `helm create <application-name>` \
*Have a look at the conventions guide for some naming conventions and general best practices. [Helm Best practices](https://helm.sh/docs/chart_best_practices/conventions/).*

4. You will have a couple of files ready for you to update and make your chart. The important bits of your chart should and be exposed through the *values.yml* file.

In this guide I will be assuming a couple of things. One of them is that you already have a dockerised application.

### Prepare your image.
We are going to use AWS ECR to store out images. You can use other solutions, gitlab enterprise has a great Container Registry and so does Dockerhub if you are looking for an managed solution.\
*Assuming you have logged into AWS ECR and you have a repository namespaced misc-images/your-image-name* \
1. Build and tag your image\
`docker build -t misc-images/heyweather.dev .`\
*I have name spaced my image misc-images and named it heyweather.dev* \

2. Tag Image and push to repository:\
`docker tag misc-images/heyweather.dev:latest <account-id>.dkr.ecr.us-east-1.amazonaws.com/misc-images/heyweather.dev:latest`

3. Push to repository:
`docker push <account-id>.dkr.ecr.us-east-1.amazonaws.com/misc-images/heyweather.dev:latest`\
*Replace account id and region as per your ECR account*


### With the chart ready and your Docker Image ready. 
Time to update your chart and reference the docker image. 

## TODO :
[] Update application Repo context and connect to Postgres instance.\
[] Load balance application.\
[] Script helm deployment and build commands.\
[] Enable secrets for config settings to database in app settings.\
[] Add health check endpoint on .net service.\


