export interface Recipe {
    recipeId: number;
    userId: string;
    name: string;
    description: string;
    imgSrc: string;
    ingredientIds: number[];
}
