import express from "express";
import UserController from "../controllers/users";

const router = express.Router();

router.get("/", (req: any, res: any) =>
  UserController.getUsers(req, res)
);

router.get("/:id", (req: any, res: any) =>
  UserController.getUserById(req, res)
);

router.post("/", (req: any, res: any) =>
  UserController.createUser(req, res)
);

router.put("/:id", (req: any, res: any) =>
  UserController.updateUser(req, res)
);

router.delete("/:id", (req: any, res: any) =>
  UserController.deleteUserById(req, res)
);

export default router;
