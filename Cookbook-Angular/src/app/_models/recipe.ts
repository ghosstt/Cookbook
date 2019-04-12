export interface Recipe {
    recipeId: number;
    userId: number;
    name: string;
    description: string;
    imgSrc: string;
    ingredientIds: number[];
}
