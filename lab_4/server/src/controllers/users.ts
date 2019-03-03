import { Request, Response } from "express";
import User from "../models/user";
import IUserService from "../services/IUserService";
import UserService from "../services/userService";

class UserController {
  constructor( private userService: IUserService = UserService) {

  }

  public async getUsers(req: Request, res: Response) {
    const users = await this.userService.getUsers();

    // tslint:disable-next-line:no-console
    console.log("res", users);
    res.status(200).json(users);
  }
}

export default new UserController();
