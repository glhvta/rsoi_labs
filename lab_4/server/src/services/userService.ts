import User from "../models/user";
import UserModel from "../models/userModel";
import IUserService from "./IUserService";

class UserService implements IUserService {
  public getUsers(): Promise<User[]> {
    return UserModel.find().exec();
  }

  public getUserById(id: number): Promise<User> {
    return UserModel.findById(id).exec();
  }

  public async createUser(user: User): Promise<User> {
    // TODO: refactor somehow
    await UserModel.create({
      surname: user.surname,
      name: user.name,
      birthday: user.birthday,
      sex: user.sex,
      passportSeries: user.passportSeries,
      passportIssued: user.passportIssued,
      passportIssueDate: user.passportIssueDate,
      patronymic: user.patronymic,
      passportId: user.passportId,
      birthPlace: user.birthPlace,
      actualLivingPlace: user.actualLivingPlace,
      homePhone: user.homePhone,
      mobilePhone: user.mobilePhone,
      registrationСity: user.registrationСity,
      citizenship: user.citizenship,
      maritalStatus: user.maritalStatus,
      disabilities: user.disabilities,
      isRetiree: user.isRetiree,
      monthlyIncome: user.monthlyIncome,
    });

    return user;
  }

  // public updateUser(user: User): Promise<User | null> {
  //   return UserModel.findByIdAndUpdate(, user);
  // }

  public deleteUser( id: number ): Promise<User | null> {
    return UserModel.findByIdAndRemove(id).exec();
  }

}

export default new UserService();
