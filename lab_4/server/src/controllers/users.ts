import { Request, Response } from "express";

import httpstatus from "../constants/httpStatus";
import IUserService from "../services/IUserService";
import UserService from "../services/userService";

class UserController {
  constructor(private userService: IUserService = UserService) {}

  public async getUsers(req: Request, res: Response) {
    try {
      const users = await this.userService.getUsers();

      res.status(httpstatus.OK).json(users);
    } catch (e) {
      // tslint:disable-next-line:no-console
      console.log(e);

      res.status(httpstatus.BAD_REQUEST);
    }
  }

  public async getUserById(req: Request, res: Response) {
    const id = req.params.id;

    try {
      const user = await this.userService.getUserById(id);

      res.status(httpstatus.OK).json(user);
    } catch (e) {
      // tslint:disable-next-line:no-console
      console.log(e);

      res.status(httpstatus.BAD_REQUEST);
    }
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

  public async deleteUserById(req: Request, res: Response) {
    const id = req.params.id;

    try {
      await this.userService.deleteUser(id);

      res.status(httpstatus.ACCEPTED).send();
    } catch (e) {
      // tslint:disable-next-line:no-console
      console.log(e);

      res.status(httpstatus.BAD_REQUEST);
    }
  }
}

export default new UserController();
