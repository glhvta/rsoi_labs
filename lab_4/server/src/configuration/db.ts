import dotenv from "dotenv";
import mongoose from "mongoose";

const database = "user";

const initDatabase = async () => {
  dotenv.config();

  const config = {
    db: process.env.DATABASE || "mongodb",
    host: process.env.DBHOST || "localhost"
  };

  const uristring =
    process.env.MONGOLAB_URI || `${config.db}://${config.host}/${database}`;

  try {
    await mongoose.connect(uristring, {
      useNewUrlParser: true
    });

    // tslint:disable-next-line:no-console
    console.log("Connection with database is successful");
  } catch (e) {
    // tslint:disable-next-line:no-console
    console.log("Connection with database is not successful", e);
  }
};

export default initDatabase;
