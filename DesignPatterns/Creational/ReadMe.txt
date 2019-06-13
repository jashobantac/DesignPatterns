1) Factory Design Pattern :-
===========================================================================================
a) Introduction :

The factory design pattern allows the user to get instances of objects from a factory 
without having a concrete implementation. The Concrete-Implementation is done by the
Factory which is responsible for Creation of objects and appropriately return the 
appropriate objects.

b) Components :-

There are 3 components of a Factory Design Pattern :-
	a) An Interface.
	b) A set of classes which implement the interface.
	c) A factory which is responsible for creation of objects.


2) Builder Design Pattern :- 
===========================================================================================
a) Introduction :
Allows for the dynamic creation of objects based upon easily interchangeable algorithms.

When to Use
-------------------------------------------------------------------------------------------
• Object creation algorithms should be decoupled from the system.
• Multiple representations of creation algorithms are required.
• The addition of new creation functionality without changing the core code is necessary.
• Runtime control over the creation process is required.

Components
--------------------------------------------------------------------------------------------

There are 3 Components of a Builder Design Pattern :-
	1) IBuilder/Builder : The abstract/interface.
	2) Concrete Builder : The class that implements the Builder.
	3) Director			: The class that creates the complex object.
	4) Product			: The complex object.

The IBuilder is passed into the Director for instance creation which creates the Product.

3) Prototype Design Pattern :-
===========================================================================================
a) Introduction :
It allows an object to create customized objects without knowing their class or any details of how to create them. 
Rather than using creation, it uses cloning.

b) When to Use :-
-------------------------------------------------------------------------------------------
 • A class will not know what classes it will be required to create.
 • Subclasses may specify what objects should be created.
 • Parent classes wish to defer creation to their subclasses.
 • Classes to be instantiated are specified at run-time
 • Avoiding the creation of a factory hierarchy is needed
 • It is more convenient to copy an existing instance than to create a new one.

c) Components
-------------------------------------------------------------------------------------------

There are 3 Components of the Prototype pattern :
	1) Client - creates a new object by asking a prototype to clone itself.
	2) Prototype - declares an interface for cloning itself.
	3) ConcretePrototype - implements the operation for cloning itself.


4) Adapter Design Pattern :-
===========================================================================================
a) Introduction
-------------------------------------------------------------------------------------------
The adapter pattern is adapting between classes and objects. 
Like any adapter in the real world it is used to be an interface, a bridge between two objects.

b) When to Use :-
-------------------------------------------------------------------------------------------
 • A class to be used doesn’t meet interface requirements.
 • Complex conditions tie object behavior to its state.
 • Transitions between states need to be explicit.

c) Components
-------------------------------------------------------------------------------------------
There are 4 Components of the Adapter pattern :
	1) Target - defines the domain-specific interface that Client uses.
	2) Adapter - adapts the interface Adaptee to the Target interface.
	3) Adaptee - defines an existing interface that needs adapting.
	4) Client - collaborates with objects conforming to the Target interface.

The adapter is used to convert the data provided by Adaptee in a way the client expects it to be. 
The client works with the Adapter instead of working directly with the Adaptee.


5) Bridge Design Pattern :-
===========================================================================================
a) Introduction
-------------------------------------------------------------------------------------------
The Bridge Pattern is part of the Structural Design patterns. 

According to the GoF's definition, this pattern "separates an object's interface from its implementation".

Bridge acts as an intermediary between two components. 
But if we talk about the Adapter Pattern then both patterns have the same logical definition.
It acts as an intermediary is partially correct. Both are a type of intermediary between two systems, 
but the actual difference is the goal that these patterns achieve. 

The Adapter Pattern is designed to act as an intermediary when the two components are not compatible to work with each other. 
Also the Adapter Pattern can add more functionality to a source component request, before passing it on to the target component, 
with which the source component is to interact. 

On the other hand, the Bridge Pattern's purpose is to provide multiple pathways between two components that are nothing 
but achieving many to many communication between multiple implementations of the source and the target components. 

So technically, it receives a request from one of the many implementations of the source component, 
and based on the client requirements, sends it to one of the many implementations of the target component.

It helps us to create a structure, where even the interface is separated from the implementation using a bridge. 
This results in a system where a function can have multiple implementations 
and each implementation of that function can be used in multiple ways. 
So this results in a system with many-to-many mappings.

6: Flyweight Pattern
===========================================================================================
a) Introduction
-------------------------------------------------------------------------------------------
The intent of this pattern is to use sharing to support a large number of objects 
that have part of their internal state in common where the other part of state can vary.

b) When to Use :-
-------------------------------------------------------------------------------------------
 • Many like objects are used and storage cost is high.
 • The majority of each object’s state can be made extrinsic.
 • A few shared objects can replace many unshared ones.
 • The identity of each object does not matter.

c) Components
-------------------------------------------------------------------------------------------
There are 4 Components of the Adapter pattern :

	1) IFlyweight/Flyweight - Declares an interface through which flyweights can receive and act on extrinsic state.
	2) ConcreteFlyweight  - Implements the Flyweight interface and stores intrinsic state. A ConcreteFlyweight object must be sharable..
	3) FlyweightFactory - The factory creates and manages flyweight objects. 
	In addition the factory ensures sharing of the flyweight objects.
	The factory maintains a pool of different flyweight objects and returns an object from the pool if it is already created, 
	adds one to the pool and returns it in case it is new. - defines an existing interface that needs adapting.
	4) Client - A client maintains references to flyweights in addition to computing and maintaining extrinsic state.


7) State Design Pattern :-
===========================================================================================
a) Introduction
-------------------------------------------------------------------------------------------
Ties object circumstances to its behavior, allowing the object to behave in different ways based upon its internal state.

b) When to Use :-
-------------------------------------------------------------------------------------------
 • The behavior of an object should be influenced by its state.
 • Complex conditions tie object behavior to its state.
 • Transitions between states need to be explicit.

c) Components
-------------------------------------------------------------------------------------------
The classes and objects participating in this pattern are:

	1) Context  (Account) : defines the interface of interest to clients.
	Maintains an instance of a ConcreteState subclass that defines the current state.
	2) State  (State) : Defines an interface for encapsulating the behavior associated with a particular state of the Context.
	3) Concrete State  : Each subclass implements a behavior associated with a state of Context.

8) Strategy Design Pattern :-
===========================================================================================
a) Introduction
-------------------------------------------------------------------------------------------
Define a family of algorithms, encapsulate each one, and make them interchangeable. 
Strategy lets the algorithm vary independently from clients that use it.

b) When to Use :-
-------------------------------------------------------------------------------------------
 • The only difference between many related classes is their behavior.
 • Multiple versions or variations of an algorithm are required.
 • Algorithms access or utilize data that calling code shouldn’t be exposed to.
 • The behavior of a class should be defined at runtime.
 • Conditional statements are complex and hard to maintain.

c) Components
-------------------------------------------------------------------------------------------
	1) Strategy  (SortStrategy): Declares an interface common to all supported algorithms.
	Context uses this interface to call the algorithm defined by a ConcreteStrategy
	2) ConcreteStrategy  (QuickSort, ShellSort, MergeSort) : implements the algorithm using the Strategy interface.
	3) Context  (SortedList) :is configured with a ConcreteStrategy object.
	Maintains a reference to a Strategy object.	May define an interface that lets Strategy access its data.


9) Command Design Pattern :-
===========================================================================================
a) Introduction
-------------------------------------------------------------------------------------------
Encapsulate a request as an object, thereby letting you parameterize clients with different requests, 
queue or log requests, and support undoable operations.

b) When to Use :-
-------------------------------------------------------------------------------------------
• You need callback functionality.
• Requests need to be handled at variant times or in variant orders.
• A history of requests is needed.
• The invoker should be decoupled from the object handling the invocation.

c) Components
-------------------------------------------------------------------------------------------
 1) Command  (Command) : declares an interface for executing an operation.
 2) ConcreteCommand  (CalculatorCommand) : defines a binding between a Receiver object and an action
 Implements Execute by invoking the corresponding operation(s) on Receiver.
 3) Client  (CommandApp): creates a ConcreteCommand object and sets its receiver Invoker  (User).
Asks the command to carry out the request
 4) Receiver  (Calculator) : knows how to perform the operations associated with carrying out the request.

