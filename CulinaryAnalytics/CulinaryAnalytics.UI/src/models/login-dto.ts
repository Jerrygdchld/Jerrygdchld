export interface LoginDto {
    email: string;
    password: string;
    twoFactorCode: string;
    twoFactorRecoveryCode: string;
}
