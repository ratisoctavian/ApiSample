# ApiSample
The task: Develop a .NET 6 Core API to CREATE, READ, UPDATE and DELETE the Object of a User.
Details:
User will be created, deleted, updated and read to and from a database, but you can just mock the data.
Please follow the following points and use the mediator pattern
(Example: https://dotnetcoretutorials.com/2019/04/30/the-mediator-pattern-in-net-core-part-1-whats-a-mediator/)
Use this library: https://github.com/jbogard/MediatR

-	From your perspective, what are advantages / disadvantages?
-	Use a useful folder and naming structure
-	Using the mediator pattern, what would be a useful folder structure.
-	Think about a long living application where changes happen (also to existing APIs) regularly. Think about which folder structure makes sense for versioning and explain why this is a good approach.
(An API change can mean a total change in logic until the lowest tier. There might be deprecated APIs in the future that should be erased to cleanup the code base.)
-	Write integration tests. Don’t use unit tests.
-	Is the use of interfaces in your application really necessary if we don’t use unit tests? Please explain your thoughts on that.
-	Think about immutability

Extra Task: Reading of a user should be cached (1 Minute). The API should return the information if a result comes from the cache or not. Adding the query parameter useCache=false to the query will disable the cache.
This functionality should be used for all data APIs that return data from a database. How do you make it available for every developer? What could be a good approach / standardizing?
.