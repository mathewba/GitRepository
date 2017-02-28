// This is to study the usage of std in and std out

// Write a program to get 3 questions and print 3 answers

var questions = ["What is your name", "What is your job", "Where is your residence", "Whats your age"];

// var answers = ["Baiju", "Software Engineer", "Singapore", "31"];

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
var answers = new Array();

function ask(i, callback) {  
    // Ask a question for user input and get the value in answer
    r1.question(questions[i] + " ?   > > >  ", function (answer) {
        var userAnswers = answer;
        answers.push(userAnswers);
        callback(userAnswers);
    });
}

// Each question has to be asked and the callback function is invoked to get the user input
ask(0, function (answer) {
    ask(1, function (answer) {
        ask(2, function (answer) {
            ask(3, function (answer) {
                console.log("\n\n\n\n\n");
                var i = 0;
                while (i < (questions.length)) {
                    console.log(questions[i] + " > " + answers[i]);
                    i++;
                }
                console.log("\nLet's print it a funny way !\n");
                console.log(answers[0] + "," + answers[3] + " is a " + answers[1] + ". He/She stays at " + answers[2]); 
                process.exit(0);
            });
        }); 
    });   
});




