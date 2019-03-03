import { Document, model, Model, Schema } from "mongoose";
import IUser, { CITIES, CITIZENSHIP, GENDERS, MARITAL_STATUS } from "./user";

// TODO: move to utils
const enumToArray = (enumValue: any) => {
  return Object.keys(enumValue)
    .filter((key: number | string) => !isNaN(Number(enumValue[key])));
};

interface IUserModel extends IUser, Document {}

const UserSchema = new Schema({
  surname: { type: String, required: true },
  name: { type: String, required: true },
  birthday: { type: Date, required: true },
  sex: { type: String,  enum: enumToArray(GENDERS), required: true },
  passportSeries: { type: Number, required: true },
  passportIssued: { type: String, required: true },
  passportIssueDate: { type: Date, required: true },
  patronymic: { type: String, required: true },
  passportId: { type: Number, required: true },
  birthPlace: { type: String, required: true },
  actualLivingPlace: { type: String, enum: enumToArray(CITIES), required: true },
  homePhone: String,
  mobilePhone: String,
  registrationСity: { type: String, enum: enumToArray(CITIES), required: true },
  citizenship: { type: String, enum: enumToArray(CITIZENSHIP), required: true },
  maritalStatus: { type: String, enum: enumToArray(MARITAL_STATUS), required: true },
  disabilities: [String],
  isRetiree: { type: Boolean, required: true },
  monthlyIncome: Number,
});

const UserModel: Model<IUserModel> = model<IUserModel>("User", UserSchema);

export default UserModel;
