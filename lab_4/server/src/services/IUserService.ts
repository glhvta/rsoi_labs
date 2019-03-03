import User from "../models/user";

interface IUserService {
  getUsers(): Promise<User[]>;
  getUserById(id: number): Promise<User | null>;
  createUser(user: User): Promise<User>;
  // updateUser(user: User): Promise<User>;
  deleteUser(id: number): Promise<User | null>;
}

export default IUserService;
