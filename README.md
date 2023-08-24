# Dad Jokes stateside exercise in .NET (C#)
Dad Jokes API implementation for Stateside/Jane.com.
## Requirements:
- Create a publicly accessible GitHub Repo and share the link with Stateside.
- Implement the API for Random Joke and Joke Count: DadJokes.io
- Basic Free Plan will be sufficient for the exercise
- Presentation is up to you
The solution provided has some advantages and disadvantages. Here's a short list for both of them.
## Advantages:
* **Modularity and Separation of Concerns**: By structuring your code into separate classes like DadJokes, DadJokesSync, DadJokesAsync, and JSONParser, we're following the principles of modularity and separation of concerns. Each class has a specific responsibility, making your codebase more organized and maintainable.
* **Easy Testing**: The separation of concerns allows for easier unit testing. You can test each class in isolation by mocking or stubbing its dependencies. This helps ensure that each component functions correctly on its own. Due tue a time issue and this example being the second implementation of the same problem (1st in Java can be found here: https://github.com/mtorres11/stateside) this example doesn't have UT. But the context is the same as the JAVA project. 
* **Reusability**: The abstract DadJokes class serves as a common interface that can be extended to create different implementations (sync and async). This reusability can be helpful if you need to add more implementations in the future.
* **Flexibility**: By using inheritance, you can easily switch between sync and async implementations without affecting the overall structure of the code. This flexibility is especially useful when requirements change or when you need to optimize performance.
* **Encapsulation**: By encapsulating the logic related to fetching jokes and parsing responses within specific classes, you're adhering to the principles of encapsulation. This makes it easier to manage changes and updates to this logic in the future.
* **Visibility into Application Behavior**: Logs provide a real-time record of what's happening within your application. By examining the log messages, developers can understand the flow of execution, the values of variables, and the interactions between different components.
## Disadvantages:
* **Tight Coupling**: While the architecture promotes separation of concerns, it can still lead to tight coupling between classes, especially when inheritance is used extensively. Changes in the base class may affect its subclasses, potentially causing unintended consequences. This is specially related with the _JSONParser_ class
* **Single Responsibility Principle (SRP)**: Although you've separated the responsibilities into different classes, the DadJokesSync and DadJokesAsync classes still have multiple responsibilities. They handle both API requests and response parsing. This might violate the SRP and make the classes harder to maintain. For this specific use case a different approach was considered overkilling.
* **Synchronous vs. Asynchronous**: While offering both synchronous and asynchronous implementations is valuable, it can also introduce complexity. Developers need to be aware of the implications of using one approach over the other, and you may need to handle threading and concurrency concerns.
* **Testing Effort**: Unit testing is crucial, but it also requires additional effort. Not all classes has been properly tested. Code coverage is not enough for a production product.
* ## Possible improvements
* ** Builder pattern**:
* Improved Readability: When an object has a large number of optional parameters or configuration options, using a builder can make the code more readable and maintainable. It allows you to set parameters in a fluent and descriptive manner.
* Avoid Telescoping Constructors: Without a builder, if you have multiple constructors with varying parameters, it can lead to "telescoping constructors" – constructors with too many parameters that become difficult to manage. The builder pattern helps avoid this by providing a clean way to set parameters.
* Flexible Construction: The builder pattern allows you to construct objects step by step, adding only the necessary parameters at each step. This can be especially useful when you have a large number of optional parameters.
* Enforcement of Valid Configurations: With a builder, you can enforce that an object is only constructed with valid configurations. This can help prevent objects from being created with inconsistent or incorrect settings.
* Easier Maintenance: If the constructor of your class changes in the future (for example, if new optional parameters are added), you would only need to update the builder rather than modifying all the places where the constructor is used.
* Encapsulation: The details of object creation are encapsulated within the builder, making the client code cleaner and less concerned with the construction process
