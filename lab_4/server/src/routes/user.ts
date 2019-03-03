import express from "express";
import UserController from "../controllers/users";

const router = express.Router();

router.get("/", (req: any, res: any) =>
  UserController.getUsers(req, res)
);

// router.get("/:id", (req: Request, res: Response) =>
//   UserController.getUserById(req, res)
// );

router.post("/", (req: any, res: any) =>
  UserController.createUser(req, res)
);

// router.delete("/:id", (req: Request, res: Response) =>
//   UserController.deleteUser(req, res)
// );

// const userRoutes = (app: Application, userController = UserController) => {
//   app.route(userRoute)
//     .get( async (req: express.Request,
//     res: express.Response,
//     next: express.NextFunction ) =>
//     await userController.getUsers(req, res, next) )
// }

export default router;
