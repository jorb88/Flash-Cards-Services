// Arithmetic_v4.js
module.exports = function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    serviceCall = function (op, n1, n2, cloud_env) {
        var http = require('http');

        data = {
            "num1": n1,
            "num2": n2
        }
        
        var post_req  = null,
            post_data = JSON.stringify(data),
            post_options = null;

        if (op == 'multiply') {
            function_path = '/api/Multiplication';
            function_term = 'product';
        } else if (op == 'divide') {
            function_path = '/api/Division';
            function_term = 'quotent';
        } else if (op == 'add') {
            function_path = '/api/Addition';
            function_term = 'sum';
        } else if (op == 'subtract') {
            function_path = '/subtraction';
            function_term = 'difference';
        };
        
        var local_post_options = {
            hostname: 'localhost',
            port    : 7071,
            path    : function_path,
            method  : 'POST',
            headers : {
                'Content-Type': 'application/json',
                'Cache-Control': 'no-cache',
                'Content-Length': post_data.length
            }
        };

        var google_post_options = {
            hostname: 'us-central1-praxis-electron-269403.cloudfunctions.net',
            path    : function_path,
            method  : 'POST',
            headers : {
                'Content-Type': 'application/json',
                'Cache-Control': 'no-cache',
                'Content-Length': post_data.length
            }
        };

        if (cloud_env == 'google') {
            post_options = google_post_options;
        } else {
            post_options = local_post_options;
        };
                
        post_req = http.request(post_options, function (res) {
            context.log('STATUS: ' + res.statusCode);
            context.log('HEADERS: ' + JSON.stringify(res.headers));
            res.setEncoding('utf8');
            res.on('data', function (chunk) {
                //context.log('Response: ', chunk);
                serviceResponse = chunk;
                context.log('Response: ', serviceResponse);
            });
        });

        post_req.on('error', function(e) {
            context.log('problem with request: ' + e.message);
        });

        post_req.write(post_data);
        post_req.end(); 
        return serviceResponse; 
    };

    if (req.body.num1 && req.body.num2 && req.body.operation) {
        
        num1 = req.body.num1;
        num2 = req.body.num2;
        operation = req.body.operation;
        
        if (operation == 'multiply') {
            response = serviceCall(operation, num1, num2, 'local');
        } else if (operation == 'divide') {
            response = serviceCall(operation, num1, num2, 'local');
        } else if (operation == 'add') {
            response = serviceCall(operation, num1, num2, 'local');
        } else if (operation == 'subtract') {
            response = serviceCall(operation, num1, num2, 'local');
        };
        display_text = 'The ' + function_term + ' of ' + num1 + ' and ' + num2 + ' is ' + response; 
        context.res = {
            body: display_text
        };
    }
    else {
        context.res = {
            status: 400,
            body: "Please pass at two numbers and the operation type in the request body"
        };
    }
    context.done();
};

// SAMPLE REQUEST BODY
// {
//     "num1": 1,
//     "num2": 22,
//     "operation": "multiply"
// }