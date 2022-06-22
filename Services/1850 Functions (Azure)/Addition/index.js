// Addition.js
module.exports = function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    if (req.body.num1 != null && req.body.num2 != null) {
        
        num1 = req.body.num1;
        num2 = req.body.num2;

        sum = num1 + num2;
        context.res = {
            // status: 200, /* Defaults to 200 */
            body: "" + sum
        };
    }
    else {
        context.res = {
            status: 400,
            body: "Please pass two numbers in the request body"
        };
    }
    context.done();
};

// SAMPLE REQUEST BODY
// {
//     "num1": 1,
//     "num2": 22
// }
