var app = require('../src/app');

describe('app', () => {
    let context;
    let trigger;

    beforeEach(() => {
        context = {
            log: () => { },
            done: () => { }
        };
        trigger = {
            query: {}
        }
    });

    describe('without query parameter "name"', () => {
        test('sets http statuscode to 400', () => {
            const result = app(context, trigger);

            expect(context.res.status).toBe(400);
        });
    });

    describe('with query parameter "name"', () => {
        test('sets http statuscode to 200', () => {
            trigger.query.name = 'user';

            app(context, trigger);

            expect(context.res.status).toBe(200);
        });

        test('returns the parameter', () => {
            trigger.query.name = 'user';

            app(context, trigger);

            expect(context.res.body).toBe(`Hello ${trigger.query.name}!`);
        });
    });

});
