// This is to study the usage of std in and std out

// Write a program to get 3 questions and print 3 answers

var questions = ["What is your name", "What is your job", "Where is your residence", "Whats your age"];

var answers = ["Baiju", "Software Engineer", "Singapore", "31"];

//var i = 0;
//while (i < 4) {
//    console.log("First question :- %s ?", questions[i]);
//    console.log("Answer :- %s", answers[i]);
//    console.log("\n");
//    i++;
//}

// Get the values from the user and print     

// Required for accepting user input
var readline = require('readline');
var r1 = readline.createInterface(process.stdin, process.stdout);

function ask(i, callback) {
    
    // Ask a question for user input and get the value in answer
    r1.question(questions[i] + " ?   >   ", function (answer) {
        var userAnswers = answer;
        console.log(questions[i] + " ?   >   " + userAnswers);
        callback(userAnswers);
    });

}


// Each question has to be asked and the callback function is invoked to get the user input
ask(0, function (answer1) {
    ask(1, function (answer2) {
        ask(2, function (answer3) {
            ask(3, function (answer3) {
                process.exit(0);
            });
        }); 
    });   
});




