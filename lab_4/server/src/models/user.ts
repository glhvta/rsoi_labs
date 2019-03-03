export enum GENDERS { M, F }

export enum CITIES {
  Brest,
  Minsk,
  Grodno,
  Orsha,
  Vitebsk
}

export enum MARITAL_STATUS {
  Married,
  Widowed,
  Divorced,
  Single
}

export enum CITIZENSHIP {
  Belarusian,
  Rusian,
  Latvian,
}

interface IUser {
  surname: string;
  name: string;
  birthday: Date;
  sex: GENDERS;
  passportSeries: number;
  passportIssued: string;
  passportIssueDate: Date;
  patronymic: string;
  passportId: number;
  birthPlace: string;
  actualLivingPlace: CITIES;
  homePhone?: string;
  mobilePhone?: string;
  registrationСity: CITIES;
  citizenship: CITIZENSHIP;
  maritalStatus: MARITAL_STATUS;
  disabilities: string[];
  isRetiree: boolean;
  monthlyIncome?: number;
}

export default IUser;
