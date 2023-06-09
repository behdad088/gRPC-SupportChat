# About gRPC Chat Console Application
Simple .NET 6 console application that uses the gRPC framework to handle the messages between client and server. By using Bi-directional streaming in which both sides send a sequence of messages. Both data streams operate independently, allowing the client and server to read and write in any order. For example, the server could wait to receive all the client’s messages before writing its responses. Or it could alternately read a message, then write a message. Other combinations of reads and writes are also possible. Writing this simple console application helped me to understand the concept of Bi-directional streaming better and how to use it on a bigger scale in my other projects. 

If I have to summarize the entire project in one word I would just say STREAMING. As I explained in the text above Bi-directional streaming is in gRPC and what it does, it can give us a huge advantage when it comes to sending data between client and server in any order. The server can easily broadcast the message via the stream while the connection is open. What I tried to do in this application was to switch User A and User B's stream in the server to let the server broadcast the User A messages to User B and vice versa! This sounds really easy and smart! right?

![alt app services](https://github.com/behdad088/gRPC-SupportChat/blob/main/Images/gRPC.gif)

This application is a customer support console app where a customer connects to a support engineer to ask for help. As you can see in the above image the project has 2 clients (Customer and Support). The customer uses the support id to ask the chat server to connect the customer to the support. This is where the stream switching happens. The server switches the streams between support and customer and saves them into in-memory storage. After this step, the customer and support can easily send messages to each other by writing into the stream saved in the in-memory storage by their id. 

Please keep in mind that the purpose of this project is to show how gRPC streaming works that's why error handling and https were not covert fully in this project.

## How To run. 

Step one is to run the server service. After the server service is up and running you need to run the support project. After running the support project the console asks you to enter the first and last name of the support engineer. When the server has the data of the support engineer it's time to run the customer project. Here you will be asked to enter your first and last name again. Then you will be connected to the Support engineer and it's ready to chat. See the short video below.

![alt Chat](https://github.com/behdad088/gRPC-SupportChat/blob/main/Images/chat.gif)

Please STAR the repo if you liked the project. Thank you.
