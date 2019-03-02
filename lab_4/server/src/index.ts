import bodyParser from "body-parser";
import cookieParser from "cookie-parser";
import dotenv from "dotenv";
import express from "express";
import morgan from "morgan";
import path from "path";

import initDatabase from "./configuration/db";
import * as routes from "./routes";

dotenv.config();

const port = process.env.SERVER_PORT;

const app = express();

app.use(morgan("dev"));

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());

app.set( "views", path.join( __dirname, "views" ) );
app.set( "view engine", "ejs" );

routes.register( app );

initDatabase();

app.listen(port, () => {
    // tslint:disable-next-line:no-console
    console.log( `server started at http://localhost:${ port }` );
} );
