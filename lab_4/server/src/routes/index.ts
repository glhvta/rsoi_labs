import { Application } from "express";
import UserController from "../controllers/users";
import userRouter from "./user";

export const register = ( app: Application ) => {
  app.get( "/guitars", ( req: any, res ) => {
    res.render( "guitars" );
  } );

  app.get( "/", ( req: any, res ) => {
      res.render( "index" );
  } );

  app.use("/api/users", userRouter);
};
