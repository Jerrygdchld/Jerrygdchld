import { Recipe } from "./recipe";

export interface GroupedRecipe {
    group: string;
    recipes: Recipe[];
    total: number;
    selected: boolean;
}
