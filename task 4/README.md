Create a REST API application that will allow us to manage animal data in a database for a veterinary clinic shelter. An animal is described by:
id,
name,
category (e.g., dog, cat, etc.)
weight,
fur color.

We would like to have the ability to:

retrieve a list of animals
retrieve a specific animal by id
add an animal
edit an animal
delete an animal

Furthermore, we would like to record information about the animal's visits:
 we would like to be able to retrieve a list of visits associated with a given animal
 we would like to be able to add new visits

A visit includes the following information:
    date of visit
    animal
    description of the visit
    price of the visit

    Prepare an application with a REST API with appropriate HTTP endpoints - GET, POST, PUT, DELETE.
    Make sure that the structure of the endpoints is consistent with the principles of REST endpoint design.
    Use a static collection with objects as the database.
    You can use either the MinimalAPI approach or a version of the API using controller classes.
    Test the prepared application with Postman.