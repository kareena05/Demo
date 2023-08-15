const express = require('express');
require('./db/config');
const cors = require('cors');
const Users = require('./db/schemas/Users');
const app = express();

// Middlewares
app.use(express.json());
app.use(cors());

app.post("/signup", async (req, res) => {
    let user = new Users(req.body);
    let result = await user.save();
    res.send(result);
});

app.listen(5000);
