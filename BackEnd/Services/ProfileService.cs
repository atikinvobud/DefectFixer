using BackEnd.DTOs;
using BackEnd.Extentions;
using BackEnd.Repositories;

namespace BackEnd.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository profileRepository;
    public ProfileService(IProfileRepository profileRepository)
    {
        this.profileRepository = profileRepository;
    }

    public async Task<GetProfile?> GetProfileInfo(int userId)
    {
        var user = await profileRepository.GetProfile(userId);
        if (user == null) return null;
        return user.ToDTO();
    }
    public async Task<bool> UpdateProfile(PutProfile profile, int userId)
    {
        var user = await profileRepository.GetProfile(userId);
        if (user == null) return false;
        user.Update(profile);
        await profileRepository.UpdateProfile();

        return true;
    }
}