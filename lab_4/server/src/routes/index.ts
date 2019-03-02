import { Application } from "express";

export const register = ( app: Application ) => {
  app.get( "/guitars", ( req: any, res ) => {
    res.render( "guitars" );
  } );

  app.get( "/", ( req: any, res ) => {
      res.render( "index" );
  } );
};
