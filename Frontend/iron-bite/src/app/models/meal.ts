import {IBaseEntity} from "./base-entity";

export interface IMeal {
  id: IBaseEntity;
  name: string;
  description?: string;
  instruction: string;
}
