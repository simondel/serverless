module.exports = function(context, trigger, input) {
    context.log('JavaScript HTTP trigger function processed a request.');
    context.res = {
        headers: {
                'Content-Type': 'text/html'
        }
    };

    if (trigger.query.name || (trigger.body && trigger.body.name)) {
        context.res.body = "Hello " + (trigger.query.name || trigger.body.name);
    }
    else {
        context.res.status = 400;
        context.res.body = "Please pass a name on the query string or in the request body";
    }
    context.done();
};