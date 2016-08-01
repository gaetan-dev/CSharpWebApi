Feature: Projects API
	In order to perform CRUD operations on the projects
	As a client of the Web Api
	I want to be able to Create, Update, Delete, and List projects

	#Scenario Outline: Retrieving an example
	#	 Given existing examples
	#	 When all issues are retrieved
	#	 Then a '200 Ok' status is returned
	#	 Then all issues are returned
	#Examples:
	#	| Id | Prop1  | Prop2  |
	#	| 1  | Prop01 | Prop02 |
	#	| 2  | Prop11 | Prop12 |

	@create
	Scenario Outline: 01 Creating a new example
		 Given a new example '<Id>', '<Prop1>', '<Prop2>'
		 When a POST request is made
		 Then a '201 Created' status is returned
		 Then the example should be added
		 Then the response location header will be set to the resource location
	Examples:
		| Id | Prop1 | Prop2 |
		| T  | Spec01 | Spec02 |

	@readOne
	Scenario Outline: 02 Retrieving an example
		 Given an existing example '<Id>', '<Prop1>', '<Prop2>'
		 When it is retrieved
		 Then a '200 Ok' status is returned
		 Then it is returned
		 Then it should have an id
		 Then it should have a prop1 and a prop2
	Examples:
		| Id | Prop1  | Prop2  |
		| T  | Spec01 | Spec02 |

	@update
	Scenario Outline: 03 Updating an example
		 Given an example '<Id>', '<Prop1>', '<Prop2>'
		 When a PUT request is made
		 Then a '200 Ok' status is returned
		 Then the example should be updated
	Examples:
		| Id | Prop1 | Prop2 |
		| T  | Spec11 | Spec12 |

	@delete
	Scenario Outline: 04 Deleting an example
		 Given an existing example's id '<Id>'
		 When it is deleted
		 Then a '200 Ok' status is returned
		 Then the issue should be removed
	Examples:
		| Id |
		| T  |
