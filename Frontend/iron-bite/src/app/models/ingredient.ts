import {IBaseEntity} from "./base-entity";

export interface Ingredient {
  id: IBaseEntity;
  name: string;
  description?: string;
}
