//console.log('Hello world');

//var name = "Baiju John Mathew";

//console.log('Name : %s', name.indexOf('u'));

//var substr = name.slice(0); // create a string beginning with nth position

//console.log('Selected characters of Name is %s' , substr)



//// process object 
//// get and set information for the current process

//console.log();

//console.log(process.argv);

//console.log(process.argv[1]);


// Writing a function to return the index of the input argument

// Input will be user ***** greeting ********

function grab(inputArg) {
	var index = process.argv.indexOf(inputArg);
	// To print the next index
	return (index === -1) ? null : process.argv[index + 1];
}

// Get the user name
// Get the greeting

var user = grab("user");
var greeting = grab("greeting");

if (!user || !greeting) {
	console.log("You blew it !!");
} else {
	console.log("Hello %s %s", user, greeting);
}
