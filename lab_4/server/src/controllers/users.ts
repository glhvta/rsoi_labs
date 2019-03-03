import { Request, Response } from "express";

import httpstatus from "../constants/httpStatus";
import User from "../models/user";
import IUserService from "../services/IUserService";
import UserService from "../services/userService";

class UserController {
  constructor( private userService: IUserService = UserService) { }

  public async getUsers(req: Request, res: Response) {
    const users = await this.userService.getUsers();

    // tslint:disable-next-line:no-console
    console.log("res", users);
    res.status(httpstatus.OK).json(users);
  }

  public async createUser(req: Request, res: Response) {
    const user = req.body;

    try {
      const users = await this.userService.createUser(user);

      res.status(httpstatus.CREATED).json(users);
    } catch (e) {
      // tslint:disable-next-line:no-console
      console.log(e);

      res.status(httpstatus.BAD_REQUEST);
    }
  }
}

export default new UserController();
