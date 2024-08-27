import {IMeal} from "./meal";
import {Ingredient} from "./ingredient";
import {Quantity} from "./quantity";
import {IBaseEntity} from "./base-entity";

export interface IngredientMeal {
  id: IBaseEntity;
  mealId: string;
  meal: IMeal;
  ingredientId: string;
  ingredient: Ingredient;
  quantity: Quantity;
}
