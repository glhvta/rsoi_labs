import User from "../models/user";

interface IUserService {
  getUsers(): Promise<User[]>;
  getUserById(id: string): Promise<User | null>;
  createUser(user: User): Promise<User>;
  // updateUser(user: User): Promise<User>;
  deleteUser(id: string): void;
}

export default IUserService;
