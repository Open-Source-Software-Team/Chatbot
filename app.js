const directline = require("offline-directline");
const express = require("express");

const app = express();
directline.initializeRoutes(app, 3000, 'http://localhost/Chatbot/api/messages');