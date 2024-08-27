import {Ingredient} from "./ingredient";
import {IBaseEntity} from "./base-entity";

export interface Nutrient {
  id: IBaseEntity;
  ingredientId: string;
  ingredient: Ingredient;
  protein: number;
  carbohydrates: number;
  fats: number;
}
